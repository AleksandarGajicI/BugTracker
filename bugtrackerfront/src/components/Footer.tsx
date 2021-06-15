import {Typography } from "@material-ui/core";
import clsx from 'clsx';
import useStyles from "./style/MainStyle";
import CopyrightIcon from '@material-ui/icons/Copyright';

interface Props {
    isOpen: boolean
}

function Footer(props: Props) {

    const classes = useStyles()
    console.log()

    return (
        <div 
        style={{
            backgroundColor: "#89898A", 
            height: "1em", 
            display: "flex", 
            justifyContent: "center",
            alignItems: "center",
            padding: "1em",
            color: "#DDDDE0"
        }}
        className={clsx(classes.mainContent, {
            [classes.mainContentShift]: props.isOpen,
        })}
        >
            <CopyrightIcon fontSize="small"/>
            <Typography variant="caption">copyright: nobody</Typography>
        </div>
    )
}

export default Footer