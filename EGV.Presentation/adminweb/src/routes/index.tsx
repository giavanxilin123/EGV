import { Route, Routes } from "react-router-dom"
import React, { Suspense, lazy } from "react"
import Loading from "components/Loading/Loading";
import PrivateRoute from "./PrivateRoute";
import AuthPage from "../components/AuthPage/AuthPage"

interface RoutesProps {
  isAuth?: boolean;
  children?: React.ReactNode;
  location?: Partial<Location> | string;
}

const SuspenseLoading = ({ children }) => (
    <Suspense fallback={<Loading />}>{children}</Suspense>
  );

const Home = lazy(() => import("../containers/Home"));
const AloPrivate = lazy(() => import("../containers/Private"));
const NotFound = lazy(() => import("../components/NotFound/NotFound"));
const AccessDenied = lazy(() => import("../components/AccessDenied/AccessDenied"))

const AppRoutes = (props: RoutesProps) => {
    const { isAuth } = props;
    
    return (
        <SuspenseLoading>
            <Routes>
                <Route path='/auth' element={<AuthPage/>}></Route>
                <Route path='/' element={<Home/>}></Route>

                <Route path="/" element={<PrivateRoute isAuth={false} component={<Home />}/>}/>

                <Route path='/alo' element={
                  <PrivateRoute isAuth={ true } component={<AloPrivate />}></PrivateRoute>}>
                </Route>
                
                <Route element={<AccessDenied />} path="/prohibit-area" />
                <Route path="*" element={<NotFound />} />
            </Routes>
        </SuspenseLoading>   
    )
}


export default AppRoutes;