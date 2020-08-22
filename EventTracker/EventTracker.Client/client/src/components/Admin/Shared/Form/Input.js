import React from 'react';

const Input = (props) => {
    const {
        name,
        type,
        id,
        placeholder,
        value,
        // className,
        label,
        errors,
        onChange
    } = props;

    return (
        <React.Fragment>
            <label htmlFor={name} className="control-label mb-1">{label}</label>
            <input id={id} name={name} type={type} className="form-control" value={value} placeholder={placeholder} onChange={onChange}/>
            { errors.map((err, i) => (
                <p key={i} className="text-danger text-small m-t-1">{err}</p>
            ))}
            
        </React.Fragment>
    )
}

export default Input;