import HomePage from "./HomePage";
import LoginPage from "./LoginPage";
import ProjectsPage from "./ProjectsPage";
import RequestsPage from "./RequestsPage";
import TicketsPage from "./TicketsPage";
import UsersPage from "./UsersPage";

const AppRoutes = [
  {
    path: "/projects",
    sidebarName: "Projects",
    component: ProjectsPage,
  },
  {
    path: "/",
    sidebarName: "home",
    component: HomePage,
  },
  {
    path: "/login",
    sidebarName: "Login",
    component: LoginPage,
  },
  {
    path: "/requests",
    sidebarName: "My requests",
    component: RequestsPage,
  },
  {
    path: "/tickets",
    sidebarName: "Tickets",
    component: TicketsPage,
  },
  {
    path: "/users",
    sidebarName: "Manage users",
    component: UsersPage,
  },
];

export default AppRoutes;
