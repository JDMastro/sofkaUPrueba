import * as yup from "yup";

interface initialFValuesTypes{
    [name: string]: any;
}

export const PlayersSchema: initialFValuesTypes = yup.object({
    Username: yup.string().required("Este campo es requerido"),
    Password: yup.string().required("La contraseña es requerida"),
})