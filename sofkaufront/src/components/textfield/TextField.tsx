import React from 'react';
import TextField from '@mui/material/TextField';
import InputAdornment from '@mui/material/InputAdornment';

interface textFieldProps{
    name: string,
    label: string,
    value: string,
    error: any,
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void,
    autofocus: boolean,
    type: string,
    inputInside? : any,
    disabled? : boolean
}



export function TextFieldUi({ name, label, value, error = null, onChange, autofocus = true, type, inputInside, disabled = false }: textFieldProps) {
    return (
        <TextField
            disabled={disabled}
            variant="outlined"
            fullWidth
            autoComplete={type === "password" ? 'new-password' : 'off'}
            id={ type === "password" ? "filled-password-input" :"outlined-start-adornment"}
            label={label}
            name={name}
            value={value}
            onChange={onChange}
            autoFocus={autofocus}
            InputProps={{
                startAdornment: <InputAdornment position="start">{inputInside}</InputAdornment>,
            }}
            type={type}
            {...(error && { error: true, helperText: error })}
        />
    )
}