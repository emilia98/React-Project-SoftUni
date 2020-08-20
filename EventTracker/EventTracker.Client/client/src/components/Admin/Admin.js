import React, { Component } from 'react';
import './assets/style.css';
import './assets/custom.css';
import Header from './Shared/Header';
import Sidebar from './Shared/Sidebar';

class Admin extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div id="right-panel" className="right-panel">
                    <Header />
                </div>
            </div>
            // sidebar
            // header
            
        )
    }
}

export default Admin;