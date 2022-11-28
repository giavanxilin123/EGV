import React from 'react';
import { Navbar, Button, Nav } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAlignLeft } from "@fortawesome/free-solid-svg-icons";

const Header = () => {
    return (
        <>
            <Navbar
                bg="light"
                className="navbar shadow-sm p-3 mb-5 bg-white rounded"
                expand
            >
                <Button variant="outline-info">
                    <FontAwesomeIcon icon={faAlignLeft} />
                </Button>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="ml-auto" navbar>
                        <Nav.Link href="#">page</Nav.Link>
                        <Nav.Link href="#">page</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        </>
    )
}

export default Header;