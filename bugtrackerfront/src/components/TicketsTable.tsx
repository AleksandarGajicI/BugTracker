import {Grid, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import { useState } from "react";
import { useEffect } from "react";
import { useHistory } from "react-router-dom";
import Actions from "./actions/Actions";
import Loading from "./Loading";
import { TicketAbbrevDTO } from "./models/dtos/TicketAbbrevDTO";
import Pagination from "./Pagination";

interface Props {
    withPagination: boolean
}

function TicketsTable(props: Props) {

    const [tickets, setTickets] = useState<TicketAbbrevDTO[]>([])
    const [loading, setLoading] = useState<boolean>(false)
    const history = useHistory()

    useEffect(() => {
        setLoading(true)
        Actions.TicketActions.all()
        .then(data => {

            setTickets(data)
            setLoading(false)
        })
    }, [])

    if(loading) {
        return (
            <Loading/>
        )
    }

    function redirect(id: string, e: any) {
        e.stopPropagation()

        history.push("tickets/" + id)

    }

    return (
        <Grid
        container
        style={{backgroundColor: "#234"}}
        >
            <TableContainer 
            component={Paper}
            >
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Title:</TableCell>
                            <TableCell align="center">Status:</TableCell>
                            <TableCell align="center">Deadline:</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {tickets.map((ticket) => {
                            return (
                                <TableRow 
                                hover 
                                key={ticket.id}
                                onClick={(e) => redirect(ticket.id, e)}
                                >
                                    <TableCell component="th" scope="row">
                                    {ticket.title}
                                    </TableCell>
                                    <TableCell align="center">{ticket.status}</TableCell>
                                    <TableCell align="center">{ticket.deadline.toString().split("T")[0]}</TableCell>
                                </TableRow>
                            )
                        })}
                    </TableBody>
                    {props.withPagination && <TableFooter>
                        <TableRow>
                            <TableCell colSpan={6}>
                                <Pagination pageNum={1} onPrevClick={() => console.log("prev")} onNextClick={() => console.log("next")}/>
                            </TableCell>
                        </TableRow>   
                    </TableFooter>}
                </Table> 
            </TableContainer>
        </Grid>
    )
}

export default TicketsTable