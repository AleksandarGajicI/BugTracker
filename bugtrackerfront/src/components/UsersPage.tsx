import { Grid, TextField, Typography } from "@material-ui/core"
import { useEffect, useState } from "react"
import { useHistory } from "react-router-dom"
import Actions from "./actions/Actions"
import { HeadersBuilder } from "./actions/HeadersBuilder"
import { ParamsBuilder } from "./actions/ParamsBuilder"
import ProjectUserReqForm from "./forms/ProjectUserReqForm"
import Layout from "./Layout"
import { ProjectUserReqCreateDTO } from "./models/dtos/ProjectUserReqCreateDTO"
import { UserDTO } from "./models/dtos/UserDTO"
import UsersTable from "./UsersTable"

function UsersPage() {
    const [open, setOpen] = useState<boolean>(false)
    const [userId, setUserId] = useState<string>("")
    const [searchText, setSearchText] = useState<string>("")
    const history = useHistory()
    const headerBuilder = new HeadersBuilder()


    useEffect(() => {
        if(!localStorage.getItem("token")) {
            history.push("/")
        }
        console.log(localStorage.getItem("token"))

    }, [])

    function handleInputChange(e: any) {
        if(e.key === "Enter") {
            console.log(e.target.value)
            setSearchText(e.target.value)
            console.log(searchText)
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

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

        Actions.ProjectUserReqActions.create(req, headerBuilder.getHeaders())
        .then(data => {
            history.push("/requests")
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
                    <UsersTable searchText={searchText!} onClick={onClick}/>
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