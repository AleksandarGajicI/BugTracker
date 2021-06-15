import { TextField } from "@material-ui/core";
import { ChangeEvent } from "react";
import useStyles from "../style/MainStyle";

interface Props {
    name: string,
    label: string,
    value: string,
    onChange: (e: ChangeEvent<HTMLInputElement>) => void,
    type: string,
    error: any | null
}

function CustomInput(props: Props) {
    const {name, label, value, type, error = null, onChange} = props;
    const classes = useStyles();

    return (
        <TextField
         variant="outlined"
         label={label}
         value={value}
         classes={{root: classes.formRow}}
         name={name}
         onChange={onChange}
         {...(type === "multiLine" && {multiline: true, rowsMax: 4})}
         {...(error && {error: true, helperText: error})}
        />
    );
}

export default CustomInput;