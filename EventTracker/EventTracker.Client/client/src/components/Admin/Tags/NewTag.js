import React, { Component } from 'react';
import Input from '../Shared/Form/Input';
import axios from 'axios';
import { toast } from 'react-toastify';

class NewTag extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: {
                value: '',
                errors: []
            } 
        }
    }

    onInputChange = (e) => {
        let propName = e.target.name;
        let value = e.target.value;
        let propObj = {
            value: value,
            errors: []
        }

        if (value.length === 0) {
            propObj.errors = [ 'This field cannot be empty' ];
        }

        this.setState({
            [propName]: propObj
        });
    }

    onFormSubmit = (e) => {
        e.preventDefault();
        let { name } = this.state;
        console.log('Name = ' + name.value);
        
        axios({
            method: 'post',
            url: 'https://localhost:5001/admin/tag/add',
            data: {
                name: name.value
            }
        })
        .then(response => {
            if (response.status === 200) {
                toast.success(response.data);
                this.props.history.push('/admin/tags');
            }
        })
        .catch(error => {
            let { status, data } = error.response;

            if (status === 400) {
                if (data.Name.length > 0) {
                    this.setState({
                        name: {
                            errors: data.Name.map(e => e.errorMessage)
                        }
                    });
                }
            } else {
                toast.error(error);
            }
        });
    }

    render() {
        return (
            <React.Fragment>
                <div className="row">
                    <div className="col-md-6 m-auto">
                        <div className="card">
                            <div className="card-body">
                                <div id="form-new">
                                    <div className="card-body">
                                        <div className="card-title">
                                            <h3 className="text-center">New Tag</h3>
                                        </div>
                                        <hr />
                                        <form onSubmit={this.onFormSubmit} method="post">
                                            <div className="form-group">
                                                <Input name="name" id="name" type="text" placeholder="Tag Name" value={this.state.name.value} label="Name" errors={this.state.name.errors} onChange={this.onInputChange}/>
                                            </div>

                                            <div className="row">
                                                <div className="custom-form-button">
                                                    <button id="add-new-button" type="submit" className="btn btn-lg btn-info btn-block">
                                                        Create
                                        </button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </React.Fragment>

        )
    }
}

export default NewTag;