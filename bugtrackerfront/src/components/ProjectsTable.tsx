import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import Project from "./models/Project";
import Pagination from "./Pagination";
import {useEffect, useState} from 'react';
import Actions from "./actions/Actions";
import { Link, useHistory } from "react-router-dom";


function ProjectTable() {

    const [projects, setProjects] = useState<Project[]>([]);
    const history = useHistory()

    useEffect(() => {
        Actions.ProjectActions.all().then(response => {
            setProjects(response)
        })
    }, [])

    function onNext(nextPage: number) {
        alert(nextPage)
    }

    function onPrev(prevPage: number) {
        alert(prevPage)
    }

    function deleteProject(id: string) {
        Actions.ProjectActions.delete(id).then(response => {
            console.log(response)
        })
    }

    function redirect(id: string) {
        history.push("/projects/" + id)
    }

    function redirectToEdit(id: string, e: any) {
        e.stopPropagation()
        history.push("/projects/edit/" + id)
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
                                    onClick={() => deleteProject(project.id)}
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