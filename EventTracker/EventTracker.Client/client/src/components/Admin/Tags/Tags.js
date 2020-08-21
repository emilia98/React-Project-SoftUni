import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';

class Tags extends Component {
    state = {
        tags: []
    }

    componentDidMount() {
        axios.get('http://localhost:5001/admin/tag')
            .then((response) => {
                this.setState({
                    tags: response.data
                })
            })
            .catch(error => {
                toast.error(error.message, {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                });
            })
    }

    render() {
        return (
            <React.Fragment>
                <h1 className="admin-page-title">
                    <span className="page-title">Tags - All</span>
                    <span className="new-button">
                        <Link className="btn btn-success" to="/admin/tags/new">New Tag</Link>
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
                                <tr>
                                    <td>1.</td>
                                    <td><span>Music</span> </td>
                                    <td><span>MUSIC</span> </td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td>
                                        <span className="badge badge-complete">Complete</span>
                                    </td>
                                    <td>
                                        <span>
                                            <Link className="action-btn" to="/admin/tags/edit/id">
                                                <i className="fa fa-pencil" aria-hidden="true"></i>
                                            </Link>
                                            <Link className="action-btn" to="/admin/tags/change/status/id">
                                                <i className="fa fa-ban" aria-hidden="true"></i>
                                            </Link>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1.</td>
                                    <td><span>Music</span> </td>
                                    <td><span>MUSIC</span> </td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td>
                                        <span className="badge badge-complete">Complete</span>
                                    </td>
                                </tr><tr>
                                    <td>1.</td>
                                    <td><span>Music</span> </td>
                                    <td><span>MUSIC</span> </td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td>
                                        <span className="badge badge-complete">Complete</span>
                                    </td>
                                </tr><tr>
                                    <td>1.</td>
                                    <td><span>Music</span> </td>
                                    <td><span>MUSIC</span> </td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td><span>21.08.2020 18:45:22</span></td>
                                    <td>
                                        <span className="badge badge-complete">Complete</span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </React.Fragment>

        )
    }
}

export default Tags;