import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import Project from "./models/Project";
import Pagination from "./Pagination";
import {useEffect, useState} from 'react';
import Actions from "./actions/Actions";
import { useHistory } from "react-router-dom";
import { CircularProgress } from "@material-ui/core";


function ProjectTable() {

    const [projects, setProjects] = useState<Project[]>([]);
    const history = useHistory()
    const [loading, setLoading] = useState(false)

    useEffect(() => {

        setLoading(true)
        Actions.ProjectActions.all().then(response => {
            setProjects(response)
            setLoading(false)
        })
    }, [])

    function onNext(nextPage: number) {
        alert(nextPage)
    }

    function onPrev(prevPage: number) {
        alert(prevPage)
    }

    function deleteProject(id: string, e: any) {
        e.stopPropagation()

        const confirmed = window.confirm("Are you sure you want to delete this?")

        if(confirmed) {
            Actions.ProjectActions.delete(id).then(response => {
                console.log(response)
            })
        }

    }

    function redirect(id: string) {
        history.push("/projects/" + id)
    }

    function redirectToEdit(id: string, e: any) {
        e.stopPropagation()
        history.push("/projects/edit/" + id)
    }

    if(loading) {
        return (
            <div
            style={{
                display: "flex",
                minWidth: "100vh",
                justifyContent: "center",
                margin: "5em"
            }}
            >
                <CircularProgress style={{alignSelf: "center"}}/>
            </div>
        )
    }

    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>ProjectName</TableCell>
                        <TableCell align="center">Description</TableCell>
                        <TableCell align="right">Deadline</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {projects.map((project: Project) => {
                        return (
                            <TableRow 
                            hover 
                            key={project.id}
                            onClick={() => redirect(project.id)}
                            >
                                <TableCell component="th" scope="row">
                                {project.name}
                                </TableCell>
                                <TableCell align="center">{project.description}</TableCell>
                                <TableCell align="right">{project.deadline.toString().split("T")[0]}</TableCell>
                                <TableCell align="right">
                                    <Button 
                                    color="primary"
                                    onClick={(e) => {redirectToEdit(project.id, e)}}
                                    >
                                        EDIT
                                    </Button>
                                    <Button 
                                    color="secondary" 
                                    onClick={(e) => deleteProject(project.id, e)}
                                    >
                                        DELETE
                                    </Button>
                                </TableCell>
                            </TableRow>);
                    })}
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={6}>
                            <Pagination pageNum={1} onPrevClick={onPrev} onNextClick={onNext}/>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    );
}

export default ProjectTable;