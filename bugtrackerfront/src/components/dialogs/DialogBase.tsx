import { Dialog, DialogContent, DialogTitle, Grid, IconButton } from "@material-ui/core";
import CloseIcon from '@material-ui/icons/Close'
import useStyles from "../style/MainStyle";

interface Props {
    children: React.ReactNode,
    title: string,
    onClose: () => void,
    open: boolean
}

function DialogBase(props: Props) {

    const classes = useStyles()

    return (
        <Grid
         container
         style={{margin: "0em"}}
         className={classes.pagination}
        >
            <Dialog 
             open={props.open}
             maxWidth="md"
             >
                <Grid
                 item
                 xs={12}
                 container
                 justify="space-between"
                 direction="row"
                >
                    
                    <DialogTitle>{props.title}</DialogTitle>
                    <IconButton
                     onClick={() => props.onClose()}
                    >
                        <CloseIcon />
                    </IconButton>
                </Grid>
                <Grid
                 item
                 xs={12}
                 spacing={0}
                 classes={{root: classes.gridItemNoPadMarg}}
                 
                >
                    <DialogContent>
                        {props.children}
                    </DialogContent>
                </Grid>
            </Dialog>
        </Grid>
    );
}

export default DialogBase;