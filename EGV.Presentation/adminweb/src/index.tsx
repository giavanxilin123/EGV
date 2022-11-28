import React from 'react';
import ReactDOM from "react-dom/client";
import './index.css';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter } from "react-router-dom";
import AppRoutes from 'routes';

function App() {
    const isAuth = false;
    return (
        // <Provider>
            <BrowserRouter>
                <AppRoutes isAuth ={isAuth}/>
            </BrowserRouter>
        // </Provider>
    )
}
const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <App></App>
);
serviceWorker.unregister();
