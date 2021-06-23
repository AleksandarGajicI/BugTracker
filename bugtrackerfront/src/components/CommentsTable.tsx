import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow, Typography } from "@material-ui/core";
import { useEffect, useRef, useState } from "react";
import { useHistory } from "react-router-dom";
import Actions from "./actions/Actions";
import { HeadersBuilder } from "./actions/HeadersBuilder";
import { CommentDTO } from "./models/dtos/CommentDTO";
import Pagination from "./Pagination";
interface Props {
    comments: CommentDTO[],
    searchText: string,
    deleteComment: (id: string) => void
}

function CommentsTable(props: Props) {
    const searchText = useRef(props.searchText)
    const [pageNum, setPageNum] = useState<number>(1)
    const headerBuilder = new HeadersBuilder()
    const history = useHistory()
    
    function onPaginationClicked(pageNum: number) {
        alert(pageNum)
    }

    function onDelete(id: string) {
        const confirmed = window.confirm(`Are you sure you want to delete ${id}?`)

        if(confirmed) {
            headerBuilder.resetHeaders()
            .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

            Actions.CommentActions.delete(id, headerBuilder.getHeaders())
            .then(() => {
                props.comments = props.comments.filter(c => c.id !== id)
            })
        }
    }

    function prevClicked() {
        if(pageNum > 1) {
            setPageNum(pageNum - 1)
        }
    }

    function nextClicked() {
        if(props.comments.length > 0) {
            setPageNum(pageNum + 1)
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
                    {props.comments.length < 0
                    ? <Typography>No Comments</Typography>
                    : props.comments.map(comment => {
                        return (
                            <TableRow 
                            hover 
                            key={comment.id}
                            >
                                <TableCell component="th" scope="row">
                                {comment.commenter.userName}
                                </TableCell>
                                <TableCell align="center">{comment.message}</TableCell>
                                <TableCell align="right">{comment.created.toString().split("T")[0]}</TableCell>
                                <TableCell align="right">
                                    <Button 
                                    color="secondary"
                                    onClick={() => {props.deleteComment(comment.id)}}
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
                            <Pagination pageNum={pageNum} onPrevClick={() => prevClicked()} onNextClick={() => nextClicked()}/>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default CommentsTable