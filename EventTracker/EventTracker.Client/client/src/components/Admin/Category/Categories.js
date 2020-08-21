import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';
import CategoryRow from './Shared/CategoryRow';

class Categories extends Component {
    state = {
        categories: []
    }

    componentDidMount() {
        axios.get('https://localhost:5001/admin/category/')
        .then(response => {
            this.setState({
                categories: response.data
            });
        })
        .catch(error => {
            toast.error(error.message);
        })
    }
    
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
                                {
                                    this.state.categories.map((category) => 
                                        <CategoryRow category={category} />
                                    )
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

export default Categories;