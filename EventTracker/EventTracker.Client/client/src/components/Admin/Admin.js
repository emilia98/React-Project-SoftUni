import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';

import './assets/style.css';
import './assets/custom.css';
import Header from './Shared/Header';
import Sidebar from './Shared/Sidebar';
import Tags from './Tags/Tags';
import NewTag from './Tags/NewTag';
import EditTag from './Tags/EditTag';

class Admin extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div id="right-panel" className="right-panel">
                    <Header />
                    <div className="content">
                        <Switch>
                            <Route exact path="/admin/tags" component={Tags} />
                            <Route path="/admin/tags/new" component={NewTag} />
                            <Route path="/admin/tags/edit/:id" component={EditTag} />
                        </Switch>
                    </div>
                </div>
            </div>
            // sidebar
            // header

        )
    }
}

export default Admin;