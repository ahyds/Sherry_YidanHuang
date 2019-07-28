-- Drop table if exists
DROP TABLE IF EXISTS departments,
dept_emp,
dept_manager,
employees,
salaries,
titles;

-- Create new table
CREATE TABLE departments (
	dept_no VARCHAR(5) PRIMARY KEY ,
	dept_name VARCHAR(30)
);


CREATE TABLE employees (
	emp_no INT PRIMARY KEY ,
	birth_date date,
	first_name VARCHAR(30) NOT NULL,
	last_name VARCHAR(30) NOT NULL,
	gender VARCHAR(30),
	hire_date date);


CREATE TABLE dept_emp (
	--id SERIAL PRIMARY KEY,
	emp_no int,
	FOREIGN KEY (emp_no) REFERENCES employees(emp_no),
	dept_no VARCHAR(5),
	FOREIGN KEY (dept_no) REFERENCES departments(dept_no),
	from_date date,
	to_date date
);



CREATE TABLE dept_manager (
    --id SERIAL PRIMARY KEY,
    dept_no VARCHAR(5),
    FOREIGN KEY (dept_no) REFERENCES departments(dept_no),
    emp_no int,
    FOREIGN KEY (emp_no) REFERENCES employees(emp_no),
    from_date date,
	to_date date
);

CREATE TABLE salaries (
    --id SERIAL PRIMARY KEY,
    emp_no int,
    FOREIGN KEY (emp_no) REFERENCES employees(emp_no),
    salary money,
    from_date date,
	to_date date
);

CREATE TABLE titles (
    --id SERIAL PRIMARY KEY,
    emp_no int,
    FOREIGN KEY (emp_no) REFERENCES employees(emp_no),
    title VARCHAR(30),
    from_date date,
	to_date date
);


-- View table columns and datatypes
--SELECT * FROM dept_emp;

