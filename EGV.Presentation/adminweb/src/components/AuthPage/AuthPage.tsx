import React, { useEffect } from 'react'
import { UserManager } from 'oidc-client'
import Loading from 'components/Loading/Loading';

const AuthPage = () => {
    useEffect(() => {
		var mgr = new UserManager({
			response_mode: "query",
		});
        
		mgr.signinRedirectCallback().then(() => (window.location.href = "/"));

	}, []);

	return <Loading/>;
}

export default AuthPage;