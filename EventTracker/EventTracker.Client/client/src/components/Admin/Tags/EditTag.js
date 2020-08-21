import React, { Component } from 'react';

class EditTag extends Component {
    constructor(props) {
        super(props);
        this.id = this.props.match.params.id;
    }


    render() {
        console.log(this.id);
        return (
            <h1>Edit Tag with id = {this.id}</h1>
        )
    }
}

export default EditTag;