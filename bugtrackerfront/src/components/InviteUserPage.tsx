import { useParams } from "react-router"

function InviteUserPage() {
    const {id} = useParams<{id: string}>()

    return(
        <div>
            {id}
        </div>
    )
}

export default InviteUserPage