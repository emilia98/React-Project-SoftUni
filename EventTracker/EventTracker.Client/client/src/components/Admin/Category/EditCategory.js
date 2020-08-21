import React, { Component } from 'react';

class EditCategory extends Component {
    constructor(props) {
        super(props);
        this.id = this.props.match.params.id;
    } 

    render() {
        return (
            <h1>Edit Category with id = {this.id}</h1>
        )
    }
}

export default EditCategory;