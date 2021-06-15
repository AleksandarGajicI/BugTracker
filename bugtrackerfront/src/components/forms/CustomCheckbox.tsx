import { Checkbox, FormControl, FormControlLabel } from "@material-ui/core"
import { ChangeEvent } from "react"

interface Props {
    name: string,
    value: boolean,
    onChange: (e: {target: {name: string, value: boolean}}) => void,
    label: string
}

export default function CustomCheckbox(props: Props) {

    function convertToDefaultEventParameter(e: ChangeEvent<HTMLInputElement>): {target: {name: string, value: boolean}} {
        // return {
        //     value: e.target.checked,
        //     ...e
        // }

        return  {
            target: {
                name: props.name,
                value: e.target.checked,
            }
        }

    }

    return (
        <FormControl>
            <FormControlLabel
             control={
                 <Checkbox
                  name={props.name}
                  color="primary"
                  checked={props.value}
                  onChange={e => props.onChange(convertToDefaultEventParameter(e))}
                 />
             }
             label={props.label}
             labelPlacement="top"
            />
        </FormControl>
    )
    
}