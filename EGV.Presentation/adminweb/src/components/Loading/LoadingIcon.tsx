import React from 'react'
import { Triangle } from  'react-loader-spinner'

const LoadingIcon = () => {
    return (
        <Triangle
            height="120"
            width="120"
            color="#3498db"
            ariaLabel="triangle-loading"
            wrapperStyle={{}}
            visible={true}
            />
    )
}

export default LoadingIcon;