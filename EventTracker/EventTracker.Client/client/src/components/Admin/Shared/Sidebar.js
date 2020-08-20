import React from 'react';
import { Link } from 'react-router-dom';

const Sidebar = () => (
    <aside id="left-panel" className="left-panel">
        <nav className="navbar navbar-expand-sm navbar-default">
            <div id="main-menu" className="main-menu collapse navbar-collapse">
                <ul className="nav navbar-nav">
                    <li className="menu-title">Home</li>
                    <li>
                        <Link to="/admin"><i className="menu-icon fa fa-tachometer"></i>Dashboard</Link>
                    </li>

                    <li className="menu-title">General Info</li>
                    <li>
                        <Link to="/admin/tags"><i className="menu-icon fa fa-tag"></i>Tags</Link>
                    </li>
                    <li>
                        <Link to="/admin/categories"><i className="menu-icon fa fa-tags"></i>Categories</Link>
                    </li>
                    <li>
                        <Link to="/admin/locations"><i className="menu-icon fa fa-location-arrow"></i>Locations</Link>
                    </li>
                    <li>
                        <Link to="/admin/places"><i className="menu-icon fa fa-map-marker"></i>Places</Link>
                    </li>

                    <li className="menu-title">Events</li>
                    <li>
                        <Link to="/admin/events"><i className="menu-icon fa fa-calendar"></i>Events</Link>
                    </li>
                    <li>
                        <Link to="/admin/events/requests"><i className="menu-icon fa fa-plus"></i>Events Requests</Link>
                    </li>

                    <li className="menu-title">Users</li>
                    <li>
                        <Link to="/admin/users"><i className="menu-icon fa fa-user"></i>Users</Link>
                    </li>
                    <li>
                        <Link to="/"><i className="menu-icon fa fa-chevron-left"></i>Back To User Area</Link>
                    </li>
                </ul>
            </div>
        </nav>
    </aside>
);

export default Sidebar;