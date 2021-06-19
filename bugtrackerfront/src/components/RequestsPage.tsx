import { Grid, Typography } from "@material-ui/core";
import Layout from "./Layout";
import RequestsTable from "./RequestsTable";
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import IconButton from '@material-ui/core/IconButton';
import { ExpandMoreRounded } from "@material-ui/icons";


function RequestsPage() {
    return (
        <Layout>
            <Grid
            container
            direction="column"
            style={{backgroundColor: "#999", padding: "2em"}}
            >
                <Typography variant="h5">Welcome to the Requests Page!</Typography>
                <Typography variant="h6"
                style={{marginTop: "0.7em", fontSize: "15px"}}>
                    Here you can see who invited you, and for which project. You can also view your own sent requests
                </Typography>
            </Grid>
            <Grid
            container
            direction="row"
            style={{padding: "2em"}}>
                <Grid
                item
                container
                xs={12}
                md={7}
                style={{padding: "10px",}}
                >
                    <Grid
                    container
                    item
                    justify="center"
                    alignItems="center"
                    direction="column"
                    style={{
                        backgroundColor: "#3f51b5", 
                        color: "#fff",
                        padding: "10px",
                        paddingRight: "10px",
                        paddingLeft: "10px",
                        }}
                    >
                        <Typography>Requests that you received</Typography>
                        <IconButton disabled>
                            <ExpandMoreIcon style={{color: "#fff"}} />
                        </IconButton>
                    </Grid>
                        <RequestsTable isOwner={false}/>
                </Grid>
                <Grid
                item
                container
                xs={12}
                md={5}
                style={{padding: "10px",}}
                >
                    <Grid
                    container
                    item
                    justify="center"
                    alignItems="center"
                    direction="column"
                    style={{
                        backgroundColor: "#3f51b5", 
                        color: "#fff",
                        padding: "10px",
                        paddingRight: "10px",
                        paddingLeft: "10px",
                        }}
                    >
                        <Typography>Requests that you sent</Typography>
                        <IconButton disabled>
                            <ExpandMoreIcon style={{color: "#fff"}} />
                        </IconButton>
                    </Grid>
                        <RequestsTable isOwner={true}/>
                </Grid>
            </Grid>
        </Layout>
    )
}

export default RequestsPage