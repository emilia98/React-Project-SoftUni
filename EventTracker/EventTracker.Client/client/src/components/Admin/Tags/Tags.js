import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';
import TagRow from './Shared/TagRow';

class Tags extends Component {
    state = {
        tags: []
    }

    componentDidMount() {
        axios.get('https://localhost:5001/admin/tag')
            .then((response) => {
                this.setState({
                    tags: response.data
                });
            })
            .catch(error => {
                toast.error(error.message);
            });
    }

    render() {
        console.log(this.state.tags);
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
                            {this.state.tags.map((tag) => (
                                    <TagRow tag={tag} />
                                ))}
                            </tbody>
                        </table>
                    </div>
                </div>
            </React.Fragment>

        )
    }
}

export default Tags;