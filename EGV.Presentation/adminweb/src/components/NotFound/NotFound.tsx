import React from 'react'
import NotFoundImage from '../../images/NotFound.png';

const NotFound = () => {
    return (
        <section 
            style={{
                background: `url(${NotFoundImage}) no-repeat center`,
                height: "100vh",
            }} 
            className="notfound--page"
        >
        </section>        
    )
}

export default NotFound;