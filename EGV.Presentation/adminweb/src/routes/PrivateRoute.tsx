import Layout from 'components/Layout/Layout';
import React from 'react'
import { Navigate } from 'react-router-dom'

type PrivateRouteProps = {
    isAuth?: boolean;
    component: any;
};

const PrivateRoute = ({ 
    isAuth, 
    component 
} : PrivateRouteProps) => {
    if (isAuth) {
        return <Layout> 
                    {component} 
                </Layout>;
    } else {
        return <Navigate to={{ pathname: '/auth' }} />;
    }
}

 
export default PrivateRoute;
