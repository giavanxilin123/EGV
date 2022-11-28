import React, { useState, useEffect } from 'react'
import { UserManager} from 'oidc-client'
import axios from 'axios'
import { USER_MANAGER_SETTINGS } from 'constants/setting'

const Home = () => {
    const [state, setState] = useState(null);
	const [category, setCategory] = useState([])
	const userManager = new UserManager(USER_MANAGER_SETTINGS);

	
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
				<>
					<h3>Welcome {state?.user?.profile?.name}</h3>
					<pre>{JSON.stringify(state?.data, null, 2)}</pre>
					
					<button onClick={() => userManager.signoutRedirect()}>
						Log out
					</button>
				</>
			) : (
				<>
					<h3>React Weather App</h3>
					<button onClick={() => userManager.signinRedirect()}>Login</button>
				</>
			)}
		</div>
	);
}

export default Home;