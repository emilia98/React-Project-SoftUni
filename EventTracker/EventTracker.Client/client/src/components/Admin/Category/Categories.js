import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class Categories extends Component {
    
    render() {
        return (
            <React.Fragment>
                <h1 className="admin-page-title">
                    <span className="page-title">Category - All</span>
                    <span className="new-button">
                        <Link className="btn btn-success" to="/admin/categories/new">New Category</Link>
                    </span>
                </h1>
                <div className="card">
                    <div className="card-header">
                        <strong className="card-title">Custom Table</strong>
                    </div>
                    <div className="table-stats order-table ov-h">
                        <table className="table ">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Normalized Name</th>
                                    <th>Created On</th>
                                    <th>Edited On</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

export default Categories;