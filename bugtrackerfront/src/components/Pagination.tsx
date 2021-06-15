import { Grid, IconButton, Typography } from "@material-ui/core";
import ArrowBackIosIcon from '@material-ui/icons/ArrowBackIos';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';

interface Prop {
    pageNum: number,
    onPrevClick: (currPageNum: number) => void,
    onNextClick: (currPageNum: number) => void
}

function Pagination(props: Prop) {
    const {pageNum, onPrevClick, onNextClick} = props

    return (
        <>
            <Grid
             container
             justify="flex-end"
             alignItems="center"
            >
                <Grid item>
                    <Typography
                     variant="subtitle2"
                    >
                        Current page: 
                    </Typography>
                </Grid>
                <Grid 
                 item xs={2}
                 container
                 justify="center"
                 alignItems="center"
                >
                    <IconButton size="small" onClick={() => onPrevClick(pageNum - 1)}>
                        <ArrowBackIosIcon color="primary" fontSize="small"/>
                    </IconButton>
                    <Typography variant="subtitle2">1</Typography>
                    <IconButton size="small" onClick={() => onNextClick(pageNum + 1)}>
                        <ArrowForwardIosIcon color="primary" fontSize="small"/>
                    </IconButton>
                </Grid>
            </Grid>
        </>
    );
}

export default Pagination;