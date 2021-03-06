import { Button, Grid, Typography } from "@material-ui/core"
import { useEffect, useState } from "react"
import { useHistory, useParams } from "react-router"
import Actions from "./actions/Actions"
import { HeadersBuilder } from "./actions/HeadersBuilder"
import Layout from "./Layout"
import Loading from "./Loading"
import { ProjectDTO } from "./models/dtos/ProjectDTO"
import { TicketAbbrevDTO } from "./models/dtos/TicketAbbrevDTO"
import Project from "./models/Project"
import TicketForProjectTable from "./TicketForProjectTable"
import UsersOnProjectTable from "./UsersOnProjectTable"

const initial: ProjectDTO = {
    id: "",
    name: "",
    description: "",
    deadline: "",
    closed: false,
    usersOnProject: [],
    recentTickets: [],

}

function ProjectPage() {
    const {id} = useParams<{id: string}>()
    const [loading, setLoading] = useState<boolean>(false)
    const [project, setProject] = useState<ProjectDTO>(initial)
    const [tickets, setTickets] = useState<TicketAbbrevDTO[]>([])
    const history = useHistory()
    const headerBuilder = new HeadersBuilder()

    useEffect(() => {
        setLoading(true)
        if(!localStorage.getItem("token")) {
            history.push("/")
        }

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)
        Actions.ProjectActions.getById(id, headerBuilder.getHeaders())
        .then(data => {
            setProject(data)
            console.log(data)
            Actions.TicketActions.getForProject(data.id, headerBuilder.getHeaders())
            .then(data => {
                console.log(data)
                setTickets(data)
                setLoading(false)

            })
        })
    }, [])

    function redirectToEdit() {
        history.push("/projects/edit/" + id)
    }

    if(loading) {
        return (
            <Loading />
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
                 style={{padding: "1em"}}
                >
                    <Grid
                     item
                     container
                     alignItems="center"
                     justify="space-between"
                    >
                        <Typography 
                        variant="h5"
                        >
                            {`Viewing: ${project.name} project`}
                        </Typography>
                        <Button
                        color="secondary"
                        variant="outlined"
                        style={{margin: "2em"}}
                        onClick={() => {redirectToEdit()}}
                        >
                            EDIT PROJECT
                        </Button>

                    </Grid>
                    <Grid
                     item
                     container
                     justify="flex-start"
                     direction="row"
                    >
                        <Grid
                        item
                        xs={12}
                        md={2}
                        >
                            <Typography 
                            variant="h6"
                            >
                                Description:
                            </Typography>
                        </Grid>
                        <Grid
                        item
                        xs={12}
                        md={10}
                        >
                            <Typography 
                            style={{fontSize: "1em"}}
                            >
                                {project?.description}
                            </Typography>
                        </Grid>
                        <Grid
                        item
                        xs={12}
                        md={2}
                        >
                            <Typography 
                            variant="h6"
                            >
                                Deadline:
                            </Typography> 
                        </Grid>
                        <Grid
                        item
                        xs={12}
                        md={2}
                        >
                            <Typography 
                            style={{fontSize: "1em"}}
                            >
                                {project?.deadline.split("T")[0]}
                            </Typography>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid
                 item
                 container
                 direction="row"
                 alignItems="center"
                 justify="space-around"
                >
                    <Grid
                     item
                     xs={12}
                     md={6}
                     style={{ padding: "1em"}}

                    >
                        <UsersOnProjectTable users={project!.usersOnProject}/>
                    </Grid>
                    <Grid
                     item
                     xs={12}
                     md={6}
                     style={{ padding: "1em"}}
                    >
                        <TicketForProjectTable tickets={tickets}/>
                    </Grid>
                </Grid>
            </Grid>
        </Layout>
    )
}

export default ProjectPage