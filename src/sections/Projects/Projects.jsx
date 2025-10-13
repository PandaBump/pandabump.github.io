import styles from "./ProjectsStyles.module.css";
import viberr from "../../assets/viberr.png";
import ProjectCard from "../../common/ProjectCard";

function Projects() {
  return (
    <section id="projects" className={styles.container}>
      <h1 className="sectionTitle">Projects</h1>
      <div className={styles.projectsContainer}>
        <ProjectCard
          src={viberr}
          link="https://www.github.com"
          h3="Pokedex"
          p="Pokedex App"
        />
        <ProjectCard
          src={viberr}
          link="https://www.github.com"
          h3="Nostalgia Cafe"
          p="Cafe App and Website"
          
        />
        <ProjectCard
          src={viberr}
          link="https://www.github.com"
          h3="Rent-A-Man"
          p="Property Maintenance Website"
        />
        <ProjectCard
          src={viberr}
          link="https://www.github.com"
          h3="Vibey"
          p="Music AI Model - In Progress"
        />
        <ProjectCard
          src={viberr}
          link="https://www.github.com"
          h3="Level-up Fitness"
          p="Fitness App"
        />
      </div>
    </section>
  );
}

export default Projects;
