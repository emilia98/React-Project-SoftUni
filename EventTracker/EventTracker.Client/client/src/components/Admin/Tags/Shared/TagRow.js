import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';

const TagRow = (props) => {
    const [tagState, setTagState] = useState(props.tag);

    const changeActiveStatus = () => {
        axios({
            method: 'post',
            url: `https://localhost:5001/admin/tag/status/change/${tagState.id}`,
        })
            .then(response => {
                setTagState((prevState) => ({
                    ...prevState,
                    editedOn: response.data.tag.editedOn,
                    isActive: response.data.tag.isActive
                }));
                toast.success(response.data.message);
            })
            .catch(error => {
                toast.error(error.message);
            });
    }

    return (
        <tr key={tagState.id}>
            <td>{tagState.id}</td>
            <td><span>{tagState.name}</span> </td>
            <td><span>{tagState.normalizedName}</span> </td>
            <td><span>21.08.2020 18:45:22</span></td>
            <td><span>{tagState.editedOn}</span></td>
            <td>
                {
                    tagState.isActive
                        ?
                        <span className="badge badge-complete">Active</span>
                        :
                        <span className="badge badge-danger">Non Active</span>
                }
            </td>
            <td>
                <span>
                    <Link className="action-btn" to={`/admin/tags/edit/${tagState.id}`}>
                        <i className="fa fa-pencil" aria-hidden="true"></i>
                    </Link>
                    <button className="action-btn" onClick={changeActiveStatus}>
                        <i className="fa fa-ban" aria-hidden="true"></i>
                    </button>
                </span>
            </td>
        </tr>
    )
};

export default TagRow;