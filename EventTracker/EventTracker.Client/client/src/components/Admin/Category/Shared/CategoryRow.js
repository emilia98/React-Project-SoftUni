import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';
import axios from 'axios';

const CategoryRow = (props) => {
    const [ categoryState, setCategoryState ] = useState(props.category);

    const changeActiveStatus = () => {
        axios({
            method: 'post',
            url: `https://localhost:5001/admin/category/status/change/${categoryState.id}`
        })
        .then(response => {
            setCategoryState(prevState => ({
                ...prevState,
                editedOn: response.data.category.editedOn,
                isActive: response.data.category.isActive
            }));
            toast.success(response.data.message);
        })
        .catch(error => {
            toast.error(error.message);
        });
    }

    return (
        <tr key={categoryState.id}>
            <td>{categoryState.id}</td>
            <td><span>{categoryState.name}</span> </td>
            <td><span>{categoryState.normalizedName}</span> </td>
            <td><span>21.08.2020 18:45:22</span></td>
            <td><span>21.08.2020 18:45:22</span></td>
            <td>
                {
                    categoryState.isActive
                        ?
                        <span className="badge badge-complete">Active</span>
                        :
                        <span className="badge badge-danger">Non Active</span>
                }
            </td>
            <td>
                <span>
                    <Link className="action-btn" to={`/admin/categories/edit/${categoryState.id}`}>
                        <i className="fa fa-pencil" aria-hidden="true"></i>
                    </Link>
                    <button className="action-btn" onClick={changeActiveStatus}>
                        <i className="fa fa-ban" aria-hidden="true"></i>
                    </button>
                </span>
            </td>
        </tr>
    )
}

export default CategoryRow;