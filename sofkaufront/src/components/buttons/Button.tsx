import React from 'react';
import Button from '@mui/material/Button';

interface buttonProps{
    fullWidth? : boolean
    Icon? : React.ReactChild[] | any;
    variant? : any,
    type : 'submit' | 'reset' | 'button';
    disabled: boolean,
    text: string,
    onClick?: () => void,
    color?: 'inherit'| 'primary'| 'secondary'| 'success'| 'error'| 'info'| 'warning'
}

export function ButtonUi({ color, variant, disabled = false, onClick, text, type, Icon, fullWidth = false }: buttonProps) {
    return (
        <Button
            fullWidth={fullWidth}
            variant={variant}
            startIcon={Icon}
            onClick={onClick}
            disabled={disabled}
            color={color}
            type={type}
        >
            {text}
        </Button>
    )
}