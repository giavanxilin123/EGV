import { UserManagerSettings } from "oidc-client";

export const USER_MANAGER_SETTINGS : UserManagerSettings = {
	authority: process.env.REACT_APP_AUTH_BASE_URL,
	client_id: process.env.REACT_APP_CLIENT_ID,
	redirect_uri: `${process.env.REACT_APP_REDIRECT_URI}auth`,
	post_logout_redirect_uri: process.env.REACT_APP_REDIRECT_URI,
	response_type: process.env.REACT_APP_RESPONSE_TYPE,
	scope: process.env.REACT_APP_SCOPE,
};