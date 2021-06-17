import { CircularProgress, Grid } from "@material-ui/core";

function Loading() {
    return (
        <Grid
        container
        alignItems="center"
        justify="center"
        >
            <CircularProgress />
        </Grid>
    )
}

export default Loading