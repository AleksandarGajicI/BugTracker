import { 
    Button, 
    Grid, 
    Paper, 
    Table, 
    TableBody, 
    TableCell, 
    TableContainer,
    TableFooter, 
    TableHead, 
    TableRow 
} from "@material-ui/core";
import { useHistory } from "react-router-dom";
import { TicketForProjectDTO } from "./models/dtos/TicketForProjectDTO";




const tickets: TicketForProjectDTO[] = [
    {
        id: "1",
        title: "Ticket 1",
        deadline: "20.20.2022",
        type: "BUG_ERROR",
        status: "ONGOING"
    },
    {
        id: "2",
        title: "Ticket 2",
        deadline: "20.20.2022",
        type: "BUG_ERROR",
        status: "REVIEW"
    }
]

interface Props {
    tickets: TicketForProjectDTO[]
}

function TicketForProjectTable(props: Props) {
    const history = useHistory()
    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Title</TableCell>
                        <TableCell align="center">Type</TableCell>
                        <TableCell align="center">Status</TableCell>
                        <TableCell align="right">Deadline</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {props.tickets.length > 0 && props.tickets.map(ticket => {
                        return(
                            <TableRow 
                            hover 
                            key={ticket.id}
                            >
                                <TableCell 
                                component="th" 
                                scope="row"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.title}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.type}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.status}
                                </TableCell>
                                <TableCell 
                                align="right"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.deadline.toString().split("T")[0]}
                                </TableCell>
                            </TableRow>
                        )
                    })
                    }
                    { props.tickets.length <= 0 &&
                        <TableRow>
                            <TableCell colSpan={4}
                            align="center"
                            style={{color: "#E20B0B", fontSize: "1.2em"}}>No tickets</TableCell>
                        </TableRow>
                    }
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={12}>
                            <Grid
                            container
                            justify="center">
                                <Button 
                                color="primary" 
                                variant="contained"
                                onClick={() => {history.push("/tickets")}}
                                >
                                    ADD TICKET TO PROJECT
                                </Button>
                            </Grid>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default TicketForProjectTable