import { FormControl, InputLabel, MenuItem, Select } from "@material-ui/core"
import { useState } from "react"
import useStyles from "../style/MainStyle"

interface Props {
    title: string,
    name: string,
    values: {
        id: string,
        name: string
    }[],
    onChange: (e: {target: {name: string, value: string}}) => void
}

function CustomSelect(props: Props) {
    const [value, setValue] = useState<string>("")
    const classes = useStyles()

    function convertToDefaultEventParameter(e: any) {
        setValue(e.target.value)
        console.log(e.target)
        return {
            target: e.target
        }
    }

    return (
        <FormControl
        variant="outlined"
        classes={{root: classes.formRow}}
        >
            <InputLabel>{props.title}</InputLabel>
            <Select
            value={value}
            name={props.name}
            label={props.title}
            onChange={(e) => props.onChange(convertToDefaultEventParameter(e))}
            
            >
                {props.values.map(value => {
                    return <MenuItem key={value.id} value={value.id}>{value.name}</MenuItem>
                })}
            </Select>

        </FormControl>
    )
}

export default CustomSelect