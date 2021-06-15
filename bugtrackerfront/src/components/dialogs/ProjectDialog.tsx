import ProjectForm from "../forms/ProjectForm";
import Project from "../models/Project";
import DialogBase from "./DialogBase";

interface Props {
    initialValues: Project,
    open: boolean,
    toggle: () => void,
    title: string
}

function ProjectDialog(props: Props) {

    return (
        <DialogBase
         title={props.title}
         open={props.open}
         onClose={props.toggle}
        >
            <ProjectForm />
        </DialogBase>
    );
}

export default ProjectDialog;