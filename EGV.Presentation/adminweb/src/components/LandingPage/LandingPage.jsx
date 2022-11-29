import React, { useEffect, useState } from "react";
import axios from 'axios';
import { UserManager, User } from "oidc-client";
import { USER_MANAGER_SETTINGS } from 'constants/setting'
import { Navigate } from "react-router-dom";

const LandingPage = () => {
    const [state, setState] = useState(null);
	const [category, setCategory] = useState([])
	const userManager = new UserManager(USER_MANAGER_SETTINGS);

	{/* <>
					<h3>Welcome {state?.user?.profile?.name}</h3>
					<pre>{JSON.stringify(state?.data, null, 2)}</pre>
					
					<button onClick={() => userManager.signoutRedirect()}>
						Log out
					</button>
				</> */}
	useEffect(() => {
		const controller = new AbortController();
		const signal = controller.signal;
		
		userManager.getUser().then((user) => {
			setState(user)
			if (user) {
				axios.get(
					"https://localhost:7062/api/Category", {
						headers: {
							Authorization: "Bearer " + user.access_token
						}
					}, 
					{ signal }
				)
				.then(res => {
					setCategory(res.data)
				})
			}
		})
	
		return () => {
			console.log("cancelled")
			controller.abort()
		}
	}, []);


	return (
		<div>
			{state ? (
				<Navigate to={{ pathname: '/home' }} />
			) : (
				<>
					<h3>React Weather App</h3>
					<button onClick={() => userManager.signinRedirect()}>Login</button>
				</>
			)}
		</div>
	);
}

export default LandingPage;

