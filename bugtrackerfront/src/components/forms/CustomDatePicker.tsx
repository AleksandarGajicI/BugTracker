import {KeyboardDatePicker, MuiPickersUtilsProvider} from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';
import { ChangeEvent, useEffect } from 'react';
import { MaterialUiPickersDate } from '@material-ui/pickers/typings/date';
import FormEventTarget from './FormEventTarget';

interface Props {
    name: string,
    value: Date,
    label: string,
    onChange: (e: ChangeEvent<HTMLInputElement> | FormEventTarget) => void,
    currentDate: string
}

function CustomDatePicker(props: Props) {
    const {name, value, label, onChange, currentDate} = props;

    function dateFieldFormat(value: number): String {
        if(value < 10) {
            return "0" + value
        }
        return "" + value
    }

    function convertToDateFormat(date: MaterialUiPickersDate): string {
        const dateFormat = date?.getFullYear() + 
                            "-" + 
                            dateFieldFormat((date!.getMonth() + 1)) + 
                            "-" + 
                            dateFieldFormat(date!.getDate());
        return dateFormat;
    }

    useEffect(() => {
        onChange({target: {
            name,
            value: convertToDateFormat(value)
        }})
    }, [value])

    function handleOnChange(date: MaterialUiPickersDate) {
        onChange({target: {
            name: currentDate, 
            value: date,
        }})
    }

    return (
        <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <KeyboardDatePicker
             disableToolbar
             variant="inline"
             format="MM/dd/yyyy"
             margin="normal"
             id="date-picker-inline"
             label={label}
             onChange={(date) => {handleOnChange(date)}}
             value={value}
             name={name}
             KeyboardButtonProps={{
                 'aria-label': 'change date',
             }}
            />
        </MuiPickersUtilsProvider>
    );
}

export default CustomDatePicker;