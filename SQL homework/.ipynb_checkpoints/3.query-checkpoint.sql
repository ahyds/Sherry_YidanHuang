--1. List the following details of each employee: employee number, last name, first name, gender, and salary.
select e.emp_no, e.last_name, e.first_name,
e.gender, s.salary
from employees e
left join salaries s
on e.emp_no = s.emp_no

--2. List employees who were hired in 1986.
select * from employees
where hire_date between '1986-01-01' and '1986-12-31';

--3. List the manager of each department with the following information: department number, department name, the manager's employee number, last name, first name, and start and end employment dates.
select d.dept_name, m.emp_no, e.last_name, e.first_name, m.from_date,m.to_date
from dept_manager m
join departments d
on d.dept_no = m.dept_no
join employees e
on m.emp_no = e.emp_no


--4. List the department of each employee with the following information: employee number, last name, first name, and department name.
select e.emp_no, e.last_name, e.first_name, d.dept_name
from employees e
join dept_emp de
on de.emp_no = e.emp_no
join departments d
on d.dept_no = de.dept_no



--5. List all employees whose first name is "Hercules" and last names begin with "B."

select * from employees
where  first_name ='Hercules'
AND last_name LIKE 'B%'     --"B"


select * from employees
where  first_name ='Hercules'
AND last_name LIKE 'B.%'    --"B."

--6. List all employees in the Sales department, including their employee number, last name, first name, and department name.
select e.emp_no, e.last_name, e.first_name, d.dept_name
from employees e
join dept_emp de
on de.emp_no = e.emp_no
right join (select * from departments
		   where dept_name = 'Sales') d
on d.dept_no = de.dept_no

--7. List all employees in the Sales and Development departments, including their employee number, last name, first name, and department name.
select e.emp_no, e.last_name, e.first_name, d.dept_name
from employees e
join dept_emp de
on de.emp_no = e.emp_no
right join (select * from departments
		   where (dept_name = 'Sales')
			or (dept_name = 'Development')
		   ) d
on d.dept_no = de.dept_no

--8. In descending order, list the frequency count of employee last names, i.e., how many employees share each last name.
SELECT last_name, count(last_name)
FROM employees
GROUP BY last_name
ORDER BY 2 desc;