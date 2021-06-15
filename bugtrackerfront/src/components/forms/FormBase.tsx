import { Grid, Paper } from "@material-ui/core";
import useStyles from "../style/MainStyle";
import React from 'react'

interface Props {
    children: React.ReactNode
}

function FormBase(props: Props) {
    const classes = useStyles();


    return (
        <>
        <Paper
         classes={{root: classes.formContainer}}
        >
            <form>
                <Grid
                 container
                >
                    {props.children}
                </Grid>
            </form>

        </Paper>
        </>
    );
}

export default FormBase;