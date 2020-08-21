import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

const CategoryRow = (props) => {
    const [ categoryState, setCategoryState ] = useState(props.category);

    const changeActiveStatus = () => {
        setCategoryState(prevState => ({
            ...prevState,
            isActive: !categoryState.isActive
        }));
        toast.success('Successfully changed the status of the category!');
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