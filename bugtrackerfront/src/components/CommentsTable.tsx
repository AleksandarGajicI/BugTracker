import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow, Typography } from "@material-ui/core";
import { useEffect } from "react";
import { useState } from "react";
import { CommentDTO } from "./models/dtos/CommentDTO";
import Pagination from "./Pagination";

const commenties: CommentDTO[] = [
    {
        id: "1",
        message: "comment 1",
        commenter: "Commenter 1",
        created: "10.10.2020"
    },
    {
        id: "2",
        message: "comment 2",
        commenter: "Commenter 2",
        created: "20.20.2020"
    }
]

function CommentsTable() {

    const [comments, setComments] = useState<CommentDTO[]>([])

    useEffect(() => {
        setComments(commenties)
    })

    function onPaginationClicked(pageNum: number) {
        alert(pageNum)
    }

    function onDelete(id: string) {
        const confirmed = window.confirm(`Are you sure you want to delete ${id}?`)

        if(confirmed) {
            alert("deleted")
        }
    }

    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead
                style={{backgroundColor: "#CCCCCD"}}>
                    <TableRow>
                        <TableCell>Commenter</TableCell>
                        <TableCell align="center">Message</TableCell>
                        <TableCell align="center">Created</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {comments.length < 0
                    ? <Typography>No Comments</Typography>
                    : comments.map(comment => {
                        return (
                            <TableRow 
                            hover 
                            key={comment.id}
                            >
                                <TableCell component="th" scope="row">
                                {comment.commenter}
                                </TableCell>
                                <TableCell align="center">{comment.message}</TableCell>
                                <TableCell align="right">{comment.created.toString().split("T")[0]}</TableCell>
                                <TableCell align="right">
                                    <Button 
                                    color="secondary"
                                    onClick={() => {onDelete(comment.id)}}
                                    >
                                        DELETE
                                    </Button>
                                </TableCell>
                            </TableRow>
                        )
                    })
                }
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={6}>
                            <Pagination pageNum={1} onPrevClick={onPaginationClicked} onNextClick={onPaginationClicked}/>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default CommentsTable