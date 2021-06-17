import Layout from "./Layout"
import TicketsTable from "./TicketsTable"

function TicketsPage() {
    return (
        <Layout>

            <TicketsTable withPagination={true}/>
        </Layout>
    )
}
export default TicketsPage