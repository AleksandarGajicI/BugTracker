import { Grid, TextField, Typography } from "@material-ui/core"
import { useState } from "react"
import Actions from "./actions/Actions"
import ProjectUserReqForm from "./forms/ProjectUserReqForm"
import Layout from "./Layout"
import { ProjectUserReqCreateDTO } from "./models/dtos/ProjectUserReqCreateDTO"
import { UserDTO } from "./models/dtos/UserDTO"
import UsersTable from "./UsersTable"

function UsersPage() {
    const [open, setOpen] = useState<boolean>(false)
    const [userId, setUserId] = useState<string>("")

    function handleInputChange(e: any) {
        if(e.key === "Enter") {
            console.log(e.target.value)
        }
    }

    function onClick(user: UserDTO) {
        console.log(user)
        setUserId(user.id)
        setOpen(true)
    }
    function cancel() {
        setUserId("")
        setOpen(false)
    }

    function submit(req: ProjectUserReqCreateDTO) {
        if(!userId || userId.length <= 0) {
            alert("You have to chose which user to invite")
            return
        }
        req.userAssignedId = userId

        Actions.ProjectUserReqActions.create(req)
        .then(data => {
            alert('Successfully sent request to user')
        })
    }

    return (
        <Layout>
            <Grid
            container
            justify="center"
            >
                <Grid
                container
                item
                direction="column"
                xs={12}
                md={12}
                style={{
                    padding: "2em", 
                    marginTop: "1em",
                    marginBottom: "1em", 
                    backgroundColor: "#CCCCCD"
                }}
                >
                    <Typography variant="h5">Welcome to the users page!</Typography>
                    <Typography>
                        Use this page to easily search through users and invite them to callaboration on your projects
                    </Typography>
                </Grid>
                <Grid
                item
                xs={12}
                md={12}
                >
                    <TextField
                    id="filled-full-width"
                    label="Search for user"
                    style={{ margin: 0, marginBottom: "0.5em" }}
                    fullWidth
                    margin="normal"
                    variant="filled"
                    // onChange={(e) => handleInputChange(e)}
                    onKeyDown={(e) => handleInputChange(e)}
                    />
                </Grid>
                <Grid
                item
                xs={12}
                md={12}>
                    <UsersTable onClick={onClick}/>
                </Grid>
                <Grid
                item
                xs={12}
                md={12}>
                    {open && 
                    <ProjectUserReqForm 
                    title="Send request:"
                    cancel={cancel}
                    submit={submit}
                    />}
                </Grid>
            </Grid>
        </Layout>
    )
}

export default UsersPage