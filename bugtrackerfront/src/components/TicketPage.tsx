import { Button, Grid, TextField, Typography } from "@material-ui/core"
import { useEffect, useState } from "react"
import { useHistory, useParams } from "react-router-dom"
import Actions from "./actions/Actions"
import CommentsTable from "./CommentsTable"
import Layout from "./Layout"
import Loading from "./Loading"
import { TicketDTO } from "./models/dtos/TIcketDTO"
import useStyles from "./style/MainStyle"

const ticket = ""

function TicketPage() {
    const {id} = useParams<{id: string}>()
    const [loading, setLoading] = useState<boolean>(false)
    const [ticket, setTicket] = useState<TicketDTO>()
    const history = useHistory()
    const classes = useStyles()

    useEffect(() => {
        setLoading(true)
        Actions.TicketActions.getById(id)
        .then(data => {
            console.log(data)
            setLoading(false)
            setTicket(data)
        })
        .catch(error => {
            console.log("error")
            setLoading(false)
        })
    }, [])

    if(loading) {
        return (
            <Loading/>
        )
    }

    return (
        <Layout>
            <Grid
            container
            >
                <Grid
                item
                container
                xs={12}
                md={5}
                style={{padding: "20px"}}>
                    <Grid
                    container
                    >
                        <Grid
                        container
                        item
                        style={{backgroundColor: "#3f51b5", padding: "20px"}}>
                            <Grid
                            item
                            container
                            alignItems="center"
                            xs={12}
                            md={6}>
                                <Typography 
                                variant="h5"
                                style={{color: "#fff"}}>
                                    {ticket?.title}
                                </Typography>
                            </Grid>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            justify="flex-end"
                            alignItems="center">
                                <Button 
                                variant="contained" 
                                color="secondary"
                                size="large"
                                style={{maxHeight: "56px"}}
                                onClick={() => {history.push(`/tickets/edit/${ticket?.id}`)}}
                                > EDIT</Button>
                            </Grid>
                        </Grid>
                    </Grid>
                    <Grid
                    container
                    >
                        <Grid
                        container
                        item
                        style={{backgroundColor: "#e0e0e0", padding: "20px"}}>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Ticket Description
                                </Typography>
                                <Typography
                                style={{fontSize: "1em"}}>
                                    {ticket?.description}
                                </Typography>
                            </Grid>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Ticket Type
                                </Typography>
                                <Typography
                                style={{ fontSize: "1em"}}>
                                    {ticket?.type}
                                </Typography>
                            </Grid>
                        </Grid>
                    </Grid>
                    <Grid
                    container
                    >
                        <Grid
                        container
                        item
                        style={{backgroundColor: "#e0e0e0", padding: "1em"}}>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Created At
                                </Typography>
                                <Typography
                                style={{fontSize: "1em"}}>
                                    {ticket?.created.split("T")[0] + ", " + ticket?.created.split("T")[1]}
                                </Typography>
                            </Grid>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Ticket Status
                                </Typography>
                                <Typography
                                style={{ fontSize: "1em"}}>
                                    {ticket?.status.status}
                                </Typography>
                            </Grid>
                        </Grid>
                    </Grid>
                    <Grid
                    container
                    >
                        <Grid
                        container
                        item
                        style={{backgroundColor: "#e0e0e0", padding: "1em"}}>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Deadline
                                </Typography>
                                <Typography
                                style={{fontSize: "1em"}}>
                                    {ticket?.deadline.split("T")[0] + ", " + ticket?.created.split("T")[1]}
                                </Typography>
                            </Grid>
                            <Grid
                            item
                            container
                            xs={12}
                            md={6}
                            direction="column"
                            style={{padding: "0.5em"}}>
                                <Typography 
                                style={{
                                    fontSize: "1em", 
                                    fontWeight: "bold",
                                    marginBottom: "0.5em"
                                }}>
                                    Reporter
                                </Typography><Typography
                                style={{ fontSize: "1em"}}>
                                    {ticket?.reporter.userName}
                                </Typography>
                            </Grid>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid
                item
                container
                xs={12}
                md={7}
                style={{
                    backgroundColor: "#fff", 
                    padding: "1em", 
                    paddingTop: "2em",
                    marginTop: "10em"
                }}
                direction="column">
                    <Grid
                    container
                    item
                    justify="center"
                    >
                        <Typography variant="h6">Add a comment?</Typography>
                    </Grid>
                    <Grid
                    item
                    container
                    direction="row"
                    justify="flex-start"
                    alignItems="center"
                    >
                        <Grid
                        item
                        xs={8}
                        >
                            <TextField
                            id="filled-full-width"
                            label="Enter a comment"
                            style={{ margin: 8}}
                            placeholder="Comment body"
                            fullWidth
                            margin="normal"
                            variant="filled"
                            multiline={true}
                            />
                        </Grid>
                        <Grid
                        item
                        container
                        justify="flex-end"
                        xs={4}
                        >
                            <Button variant="contained" color="secondary">ADD COMMENT</Button>
                        </Grid>
                    </Grid>
                    <Grid
                    container
                    style={{padding: "1em"}}
                    >
                        <Grid
                        container
                        item
                        style={{
                            backgroundColor: "#3f51b5", 
                            padding: "1em"
                        }}
                        >
                            <Typography
                            style={{color: "#fff"}}>
                                Comments for this ticket
                            </Typography>
                            <Grid
                            container
                            item
                            style={{
                                padding: "1em",
                            }}
                            justify="flex-end"
                            >
                                <Grid
                                item
                                xs={6}
                                >
                                    <TextField
                                    label="Search by commenter"
                                    style={{ margin: 0 }}
                                    fullWidth
                                    margin="normal"
                                    variant="filled"
                                    color="secondary"
                                    InputProps={{
                                        className: classes.input
                                    }}
                                    />
                                </Grid>
                            
                            </Grid>
                            <CommentsTable />
                        </Grid>
                    </Grid>
                </Grid>
            </Grid>
            <Grid
            container
            ></Grid>
        </Layout>
    )
}

export default TicketPage