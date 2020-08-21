import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.min.css';

import './assets/style.css';
import './assets/custom.css';
import Header from './Shared/Header';
import Sidebar from './Shared/Sidebar';
import Tags from './Tags/Tags';
import NewTag from './Tags/NewTag';
import EditTag from './Tags/EditTag';
import Categories from './Category/Categories';
import NewCategory from './Category/NewCategory';
import EditCategory from './Category/EditCategory';

class Admin extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                
                <div id="right-panel" className="right-panel">
                    <Header />
                    <div className="content">
                    <ToastContainer />
                        <Switch>
                            <Route exact path="/admin/tags" component={Tags} />
                            <Route path="/admin/tags/new" component={NewTag} />
                            <Route path="/admin/tags/edit/:id" component={EditTag} />
                            <Route exact path="/admin/categories" component={Categories} />
                            <Route path="/admin/categories/new" component={NewCategory} />
                            <Route path="/admin/categories/edit/:id" component={EditCategory} />
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