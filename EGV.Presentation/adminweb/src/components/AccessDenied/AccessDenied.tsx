import React from 'react'
import AccessDeniedImage from '../../images/AccessDenied.jpg'
import '../AccessDenied/index.css'

const AccessDenied = () => {
    return (
        <section
        >
            <div className="lock"></div>
            <div className="message">
                <h1>Access to this page is restricted</h1>
                <p>Please check with the site admin if you believe this is a mistake.</p>
                </div>
        </section>
    )
}

export default AccessDenied;