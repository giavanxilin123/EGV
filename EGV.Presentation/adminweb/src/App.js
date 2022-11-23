import React, { useState, useEffect } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { UserManager} from 'oidc-client'
import axios from 'axios'
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/signin-oidc' element={<Callback/>}></Route>
        <Route path='/' element={<HomePage/>}></Route>
      </Routes>
    </BrowserRouter>
  );
}

const IDENTITY_CONFIG = {
	authority: "https://localhost:5001",
	client_id: "admin_web_app",
	redirect_uri: "http://localhost:3000/signin-oidc",
	post_logout_redirect_uri: "http://localhost:3000",
	response_type: "code",
	scope: "offline_access openid profile SampleAPI",
};

function HomePage() {
	const [state, setState] = useState(null);
	var mgr = new UserManager(IDENTITY_CONFIG);

	useEffect(() => {
		mgr.getUser().then((user) => {
      console.log('user', user)
			if (user) {
				axios.get(
					"https://localhost:7062/api/Category", {
						headers: {
							Authorization: "Bearer " + user.access_token,
						}
					}
					)
					.then((resp) => resp.json())
					.then((data) => setState({ user, data }));
			}
		});
	}, []);

	return (
		<div>
			{state ? (
				<>
					<h3>Welcome {state?.user?.profile?.sub}</h3>
					<pre>{JSON.stringify(state?.data, null, 2)}</pre>
					<button onClick={() => mgr.signoutRedirect()}>
						Log out
					</button>
				</>
			) : (
				<>
					<h3>React Weather App</h3>
					<button onClick={() => mgr.signinRedirect()}>Login</button>
				</>
			)}
		</div>
	);
}

function Callback() {
	useEffect(() => {
		var mgr = new UserManager({
			response_mode: "query",
		});

		mgr.signinRedirectCallback().then(() => (window.location.href = "/"));
	}, []);

	return <p>Loading...</p>;
}
export default App;
