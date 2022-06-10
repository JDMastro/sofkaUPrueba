import React from 'react';
import Button from '@mui/material/Button';

interface buttonProps{
    fullWidth? : boolean
    Icon? : React.ReactChild[] | any;
    variant? : any,
    type : 'submit' | 'reset' | 'button';
    disabled: boolean,
    text: string,
    onClick?: () => void
}

export function ButtonUi({ variant, disabled = false, onClick, text, type, Icon, fullWidth = false }: buttonProps) {
    return (
        <Button
            fullWidth={fullWidth}
            variant={variant}
            startIcon={Icon}
            onClick={onClick}
            disabled={disabled}
            type={type}
        >
            {text}
        </Button>
    )
}